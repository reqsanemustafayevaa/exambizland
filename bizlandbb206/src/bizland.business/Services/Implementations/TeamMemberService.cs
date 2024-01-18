using bizland.business.Exceptions;
using bizland.business.Extentions;
using bizland.business.Services.Interfaces;
using bizland.core.Models;
using bizland.core.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizland.business.Services.Implementations
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IWebHostEnvironment _env;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository
                                 ,IWebHostEnvironment env)
        {
           _teamMemberRepository = teamMemberRepository;
            _env = env;
        }
        public async Task CreateAsync(TeamMember teamMember)
        {
            if(teamMember == null)
            {
                throw new NullReferenceException();
            }
            if(teamMember.ImageFile!=null)
            {
                if(teamMember.ImageFile.ContentType!="image/png" && teamMember.ImageFile.ContentType != "image/jpeg")
                {
                    throw new ImageContentException("ImageFile", "file must be .png or .jpeg!");
                }
                if (teamMember.ImageFile.Length > 2097167)
                {
                    throw new InvalidImageSizeException("ImageFile","file must be lower than 2mb!");
                }

            }
            teamMember.ImageUrl = teamMember.ImageFile.SaveFile(_env.WebRootPath, "uploads/teammembers");
            teamMember.CreatedDate = DateTime.UtcNow;
            teamMember.UpdatedDate = DateTime.UtcNow;
            teamMember.IsDeleted = false;
            await _teamMemberRepository.CreateAsync(teamMember);
            await _teamMemberRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if(id < 0)
            {
                throw new IdBelowZeroException();
            }
            var existMember=await _teamMemberRepository.GetByIdAsync(x=> x.Id == id); 
            if (existMember != null)
            {
                throw new NotFoundExceptions();
            }
            _teamMemberRepository.Delete(existMember);
            await _teamMemberRepository.CommitAsync();

        }

        public async Task<List<TeamMember>> GetAllAsync()
        {
            return await _teamMemberRepository.GetAllAsync().ToListAsync();
            await _teamMemberRepository.CommitAsync();
            
        }

        public  Task<TeamMember> GetByIdAsync(int id)
        {
            var existMember =  _teamMemberRepository.GetByIdAsync(x => x.Id == id);
            if (existMember != null)
            {
                throw new NotFoundExceptions();
            }
            return existMember;
        }

        public async Task SoftDelete(int id)
        {
            if (id < 0)
            {
                throw new IdBelowZeroException();
            }
            var existMember = await _teamMemberRepository.GetByIdAsync(x => x.Id == id);
            if (existMember != null)
            {
                throw new NotFoundExceptions();
            }
            existMember.IsDeleted=!existMember.IsDeleted;
            await _teamMemberRepository.CommitAsync();
        }

        public async Task UpdateAsync(TeamMember teamMember)
        {
            if (teamMember == null)
            {
                throw new NullReferenceException();
            }
            var existteammember= await _teamMemberRepository.GetByIdAsync(x=>x.Id == teamMember.Id && x.IsDeleted==false);
            if (existteammember != null)
            {
                throw new NotFoundExceptions();
            }
            if (teamMember.ImageFile != null)
            {
                if (teamMember.ImageFile.ContentType != "image/png" && teamMember.ImageFile.ContentType != "image/jpeg")
                {
                    throw new ImageContentException("ImageFile", "file must be .png or .jpeg!");
                }
                if (teamMember.ImageFile.Length > 2097167)
                {
                    throw new InvalidImageSizeException("ImageFile", "file must be lower than 2mb!");
                }
                Helper.DeleteFile(_env.WebRootPath, "uploads/teammembers", existteammember.ImageUrl);
                teamMember.ImageUrl = teamMember.ImageFile.SaveFile(_env.WebRootPath, "uploads/teammembers");
                
            }
            existteammember.Name = teamMember.Name;
            existteammember.Profession=teamMember.Profession;
            existteammember.InstaUrl = teamMember.InstaUrl;
            existteammember.FbUrl = teamMember.FbUrl;
            existteammember.LinkedinUrl = teamMember.LinkedinUrl;
            existteammember.TwitterUrl = teamMember.TwitterUrl;
            existteammember.UpdatedDate = DateTime.UtcNow;
            await _teamMemberRepository.CommitAsync();



        }
    }
}
